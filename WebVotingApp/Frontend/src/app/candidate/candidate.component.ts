import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {Candidate} from "../model/candidate";
import {CandidateService} from "../services/candidate-service";
import {MatDialog, MatDialogConfig} from "@angular/material/dialog";
import {AddCandidateComponent} from "../add-candidate/add-candidate.component";

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})
export class CandidateComponent implements  OnInit{

  candidatesData: MatTableDataSource<Candidate>;
  private candidateList: Candidate[] = [];
  @Output()
  candidateEvent = new EventEmitter();

  displayedColumns: string[] = ['Name','Votes'];

  constructor(private candidateService: CandidateService,
              private dialog: MatDialog
  ) {
    this.candidatesData = new MatTableDataSource<Candidate>();
  }

  ngOnInit(): void {
    this.getCandidates();
  }

  private getCandidates(): void {
    this.candidateService.getCandidates().subscribe(
      (response) => {
        this.candidatesData = new MatTableDataSource<Candidate>(response);
      }
    )
  }

  public refresh(): void {
    this.getCandidates();
  }
  openAddDialog(): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = false;
    dialogConfig.width = '29%';
    const dialogRef = this.dialog.open(AddCandidateComponent, dialogConfig);
    dialogRef.afterClosed().subscribe( () =>{
      this.refresh();
      this.candidateEvent.emit();
    })
  }

}
