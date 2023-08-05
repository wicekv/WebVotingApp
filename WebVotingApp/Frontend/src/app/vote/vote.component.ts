import {Component, EventEmitter, Output} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Voter} from "../model/voter";
import {VoterService} from "../services/voter-service";
import {CandidateService} from "../services/candidate-service";
import {Candidate} from "../model/candidate";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.css']
})
export class VoteComponent {

  @Output()
  voteEvent = new EventEmitter();
  voters: Voter[] = [];
  candidates: Candidate[] = [];
  voterId: number = 0;
  candidateId: number = 0;
  voteForm = new FormGroup({
    idCandidate: new FormControl('', Validators.required),
    idVoter: new FormControl('', Validators.required)

  })

  constructor(private voterService: VoterService,
              private snackBar: MatSnackBar,
              private candidateService: CandidateService) {
    this.getVoters();
    this.getCandidates();
  }

  private getVoters(): void {
    this.voterService.getVoters().subscribe(
      (response) => {
        this.voters = response.filter((voter) => !voter.hasVoted);
      }
    )
  }
   refreshCandidates() {
    this.getCandidates();
  }

  refreshVoters() {
    this.getVoters();
  }

  private getCandidates(): void {
    this.candidateService.getCandidates().subscribe(
      (response) => {
        this.candidates = response;
      }
    )
  }
  vote() {
    this.voterService.voteForCandidate(this.voterId, this.candidateId).subscribe(
      (response) => {
        this.voteEvent.emit();
        this.snackBar.open("Successfully voted",'',{
          duration: 2500,
          verticalPosition: 'top'
        });
      }, (error: any) => {
        this.snackBar.open("Voting error" + error.message, '', {
          duration: 2500,
          verticalPosition: 'top'
        });
      }
      )
  }
}
