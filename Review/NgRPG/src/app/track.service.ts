import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Track } from '../models/Track'

@Injectable({
  providedIn: 'root'
})
export class TrackService {
  userIsLoggedIn = new Subject<Boolean>()
  apiRoot = 'https://randomplaylistgenerator.azurewebsites.net/'

  // In here, you ask for dependencies you need 
  constructor(private http: HttpClient) { }

  getAllTracks() : Observable<Track[]> {
    return this.http.get(this.apiRoot + 'tracks') as Observable<Track[]>
  }

  createNewTrack(data: Track): Observable<Object> {
    return this.http.post(this.apiRoot + 'track', data)
  }

  formatTimeLength(timespan : string) : string {
    const [m, s] = timespan.split(":")

    return `0.00:${m}:${s}.0000`
  }
}