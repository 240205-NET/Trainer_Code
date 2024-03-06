import { Component } from '@angular/core';
import { TrackService } from '../track.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  constructor(private _trackService: TrackService) {}

  logOutUser() : void {
    this._trackService.userIsLoggedIn.next(false)
  }

}