import { Component } from '@angular/core';

@Component({
  selector: 'app-hello',
  templateUrl: './hello.component.html',
  styleUrls: ['./hello.component.css']
})
export class HelloComponent {
  isTrue : Boolean = true
  pets : string[] = ['Auryn', 'Stinker', 'Mizza', 'Spoon', 'Pinky', 'Lucy', 'Copper', 'Trixie', 'Ivy', 'Tweety', 'Renegade', 'Esther', 'Van', 'Soshana', 'Virus']
  showPets : Boolean = true
  attrBinding : string = "container"
  negateIsTrue() : void {
    this.isTrue = !this.isTrue
  }
  negateShowPets() : void {
    this.showPets = !this.showPets
  }
}
