import {Component, EventEmitter, Output} from '@angular/core';
import {VoterService} from "../services/voter-service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MatSnackBar} from "@angular/material/snack-bar";
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-add-voter',
  templateUrl: './add-voter.component.html',
  styleUrls: ['./add-voter.component.css']
})
export class AddVoterComponent {


  constructor(private voterService: VoterService,
              private snackBar: MatSnackBar,
              private dialogRef: MatDialogRef<AddVoterComponent>) {
  }

  voterForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(1),Validators.maxLength(50)])

  })

  create(name: string): void {
    this.voterService.addVoter(name).subscribe(() => {
      this.close();
      this.snackBar.open("Voter created successfully",'', {
        duration: 2500,
        verticalPosition: 'top'
      });
    },(error: any) => {
      this.snackBar.open("Cannot create a voter with error: " + error.message,'', {
        duration: 2500,
        verticalPosition: 'top'
      });
    })
  }

  private close(): void {
    this.dialogRef.close();
  }
}
