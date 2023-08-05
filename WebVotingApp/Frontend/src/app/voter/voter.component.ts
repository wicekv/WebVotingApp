import {Component, EventEmitter, OnInit, Output, ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {Voter} from "../model/voter";
import {VoterService} from "../services/voter-service";
import {MatDialog, MatDialogConfig} from "@angular/material/dialog";
import {AddVoterComponent} from "../add-voter/add-voter.component";

@Component({
  selector: 'app-voter',
  templateUrl: './voter.component.html',
  styleUrls: ['./voter.component.css']
})
export class VoterComponent implements OnInit{
  votersData: MatTableDataSource<Voter>;
  private votersList: Voter[] = [];
  displayedColumns: string[] = ['Name', 'HasVoted'];

  @Output()
  voterEvent = new EventEmitter();


  constructor(private voterService: VoterService,
              private dialog: MatDialog) {
    this.votersData = new MatTableDataSource<Voter>();
  }

  ngOnInit(): void {
    this.getVoters();
  }

  private getVoters(): void {
    this.voterService.getVoters().subscribe(
      (response) => {
        this.votersData = new MatTableDataSource<Voter>(response);
      }
    )
  }

  openAddDialog(): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = false;
    dialogConfig.width = '29%';
    const dialogRef = this.dialog.open(AddVoterComponent, dialogConfig);
    dialogRef.afterClosed().subscribe( () =>{
      this.refresh();
      this.voterEvent.emit();
    })
  }

  public refresh() {
    this.getVoters();
  }
}
