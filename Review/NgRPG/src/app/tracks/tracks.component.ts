import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Track } from '../../models/Track'

@Component({
  selector: 'app-tracks',
  templateUrl: './tracks.component.html',
  styleUrls: ['./tracks.component.css']
})
export class TracksComponent implements OnInit{
  tracks : Track[] = []
  // Angular Dependency Injection
  constructor(private http: HttpClient) {}
  // Lifecycle hook for OnInit, and will execute/run when this component loads on page
  ngOnInit(): void {
    // Observable 
    this.http.get('http://localhost:5294/tracks').subscribe((res) => {
      this.tracks = res as Track[];
    })
  }
}
