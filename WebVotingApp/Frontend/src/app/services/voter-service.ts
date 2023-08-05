import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {Voter} from "../model/voter";

@Injectable({
  providedIn: 'root'
})
export class VoterService {

  private url: string = '';

  constructor(private http: HttpClient) {
    this.url = environment.appUrl + 'api/voters';

  }

  getVoters(): Observable<Voter[]> {
    return this.http.get<Voter[]>(this.url, {observe: 'body', responseType: 'json'});
  }

  addVoter(name: string): Observable<any> {
    return this.http.post(environment.appUrl + 'api/create/voter',{
      name: name
    }, {
      observe: 'body',
      responseType: 'json'
    })
  }
  voteForCandidate(idVoter: number, idCandidate: number): Observable<any>{
    return this.http.put(environment.appUrl + 'api/vote', {
      VoterId: idVoter,
      CandidateId: idCandidate
    }, {
      observe: 'body',
      responseType: 'json'
    })
  }
}
