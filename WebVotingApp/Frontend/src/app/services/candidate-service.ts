import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {Candidate} from "../model/candidate";
import {Injectable} from "@angular/core";


@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  private url: string = '';

  constructor(private  http: HttpClient) {
    this.url = environment.appUrl + 'api/candidates'
  }

  getCandidates(): Observable<Candidate[]> {
    return this.http.get<Candidate[]>(this.url, {observe: 'body',responseType: 'json'});
  }

  addCandidate(name: string): Observable<any> {
    return this.http.post(environment.appUrl + 'api/create/candidate',{
      name: name
    }, {
      observe: 'body',
      responseType: 'json'
    })
  }
}
