import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TracksComponent } from './tracks/tracks.component';
import { AddNewTrackComponent } from './add-new-track/add-new-track.component';

const routes: Routes = [
  {
    path: 'tracks',
    component: TracksComponent 
  },
  {
    path: 'new-track',
    component: AddNewTrackComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
