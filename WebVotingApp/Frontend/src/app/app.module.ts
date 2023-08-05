import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTableModule} from "@angular/material/table";
import {MatGridListModule} from "@angular/material/grid-list";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {HttpClientModule} from "@angular/common/http";
import { VoterComponent } from './voter/voter.component';
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";
import {CandidateComponent} from "./candidate/candidate.component";
import { AddVoterComponent } from './add-voter/add-voter.component';
import {ReactiveFormsModule} from "@angular/forms";
import {MatDialog, MatDialogModule} from "@angular/material/dialog";
import {MatSnackBar, MatSnackBarModule} from "@angular/material/snack-bar";
import { VoteComponent } from './vote/vote.component';
import {MatSelectModule} from "@angular/material/select";
import { AddCandidateComponent } from './add-candidate/add-candidate.component';

@NgModule({
  declarations: [
    AppComponent,
    VoterComponent,
    CandidateComponent,
    AddVoterComponent,
    VoteComponent,
    AddCandidateComponent
  ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        MatTableModule,
        MatGridListModule,
        MatFormFieldModule,
        MatInputModule,
        HttpClientModule,
        MatButtonModule,
        MatIconModule,
        ReactiveFormsModule,
        MatDialogModule,
        MatSnackBarModule,
        MatSelectModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
