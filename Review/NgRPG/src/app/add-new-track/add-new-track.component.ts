import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-new-track',
  templateUrl: './add-new-track.component.html',
  styleUrls: ['./add-new-track.component.css']
})
export class AddNewTrackComponent {
  newTrackForm : FormGroup = new FormGroup({
    trackId: new FormControl(0)
  })

  submitForm() : void {
    console.log(this.newTrackForm);
  }
}
