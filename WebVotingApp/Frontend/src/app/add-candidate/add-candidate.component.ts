import {Component, EventEmitter, Output} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {MatSnackBar} from "@angular/material/snack-bar";
import {MatDialogRef} from "@angular/material/dialog";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {CandidateService} from "../services/candidate-service";

@Component({
  selector: 'app-add-candidate',
  templateUrl: './add-candidate.component.html',
  styleUrls: ['./add-candidate.component.css']
})
export class AddCandidateComponent {

  constructor(private candidateService: CandidateService,
              private snackBar: MatSnackBar,
              private dialogRef: MatDialogRef<AddCandidateComponent>) {
  }

  candidateForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(1),Validators.maxLength(50)])
  })

  create(name: string): void {
    this.candidateService.addCandidate(name).subscribe(() => {
      this.close();
      this.snackBar.open("Candidate created successfully",'', {
        duration: 2500,
        verticalPosition: 'top'
      });
    },(error: any) => {
      this.snackBar.open("Cannot create a candidate with error: " + error.message,'', {
        duration: 2500,
        verticalPosition: 'top'
      });
    })
  }

  private close(): void {
    this.dialogRef.close();
  }

}
