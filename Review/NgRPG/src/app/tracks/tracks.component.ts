import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Track } from '../../models/Track'
import { TrackService } from '../track.service';

@Component({
  selector: 'app-tracks',
  templateUrl: './tracks.component.html',
  styleUrls: ['./tracks.component.css']
})
export class TracksComponent implements OnInit{
  tracks : Track[] = []
  userLoggedIn :Boolean = true;
  // Angular Dependency Injection
  constructor(private _trackService: TrackService) {}
  
  // Lifecycle hook for OnInit, and will execute/run when this component loads on page
  ngOnInit(): void {
    // Observable 
    this._trackService.getAllTracks().subscribe({
      // Handle success case
      next: res => this.tracks = res,
      // Handle errors
      error: err => console.error(err)
    })

    this._trackService.userIsLoggedIn.subscribe(update => {
      console.log('was told user is no longer logged in')
      this.userLoggedIn = update
    })
  }
}