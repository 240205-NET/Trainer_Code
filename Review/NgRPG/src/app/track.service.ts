import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Track } from '../models/Track'

@Injectable({
  providedIn: 'root'
})
export class TrackService {
  userIsLoggedIn = new Subject<Boolean>()

  // In here, you ask for dependencies you need 
  constructor(private http: HttpClient) { }

  getAllTracks() : Observable<Track[]> {
    return this.http.get('http://localhost:5294/tracks') as Observable<Track[]>
  }

  createNewTrack(data: Track): Observable<Object> {
    return this.http.post('http://localhost:5294/track', data)
  }

  formatTimeLength(timespan : string) : string {
    const [m, s] = timespan.split(":")

    return `0.00:${m}:${s}.0000`
  }
}