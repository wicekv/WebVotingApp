import {Component, OnInit, ViewChild, ViewChildren} from '@angular/core';
import {VoterComponent} from "./voter/voter.component";
import {CandidateComponent} from "./candidate/candidate.component";
import {Candidate} from "./model/candidate";
import {VoteComponent} from "./vote/vote.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {

  @ViewChild(VoterComponent)
  voter: VoterComponent | undefined;

  @ViewChild(CandidateComponent)
  candidate: CandidateComponent | undefined;

  @ViewChild(VoteComponent)
  vote: VoteComponent | undefined;

  constructor() {
  }

  refreshTables() {
    this.voter?.refresh();
    this.candidate?.refresh();
  }

  refreshVotingSelectorCandidates() {
    this.vote?.refreshCandidates();
  }

  refreshVotingSelectorVoters() {
    this.vote?.refreshVoters();
  }
}
