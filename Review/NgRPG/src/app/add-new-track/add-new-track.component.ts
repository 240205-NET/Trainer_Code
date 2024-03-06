import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TrackService } from '../track.service';

@Component({
  selector: 'app-add-new-track',
  templateUrl: './add-new-track.component.html',
  styleUrls: ['./add-new-track.component.css']
})
export class AddNewTrackComponent {
  constructor(private trackService : TrackService) {}
  newTrackForm : FormGroup = new FormGroup({
    trackId: new FormControl(0, [Validators.required]),
    artistName: new FormControl('', [Validators.required]),
    trackName: new FormControl('', [Validators.required]),
    genre: new FormControl('', [Validators.required]),
    trackLength: new FormControl('', [Validators.required, Validators.pattern("([0-5]?[0-9]):([0-5][0-9])")])
  })

  submitForm() : void {
    console.log(this.newTrackForm);
    if(this.newTrackForm.valid) {
      // Send the POST Request
      let data = {...this.newTrackForm.value, trackLength: this.trackService.formatTimeLength(this.newTrackForm.value.trackLength)}

      console.log(data)
      this.trackService.createNewTrack(data).subscribe(res => console.log(res))
    }
  }
}
