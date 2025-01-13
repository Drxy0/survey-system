import { Component, EventEmitter, Input, input, Output } from '@angular/core';

@Component({
  selector: 'app-user-profile',
  standalone: true,
  imports: [],
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent {
  // Takes data from outside, set in app.html
  //@Input({required: true}) idk!: string;
  // Same thing, but uses signals instead of decorators
  idk = input.required<string>();
  
  @Output() select = new EventEmitter();

  onSelectUser() {
    this.select.emit();
  }

  // a public property that can be used in the html
  selectedUser = {
    id: 'u1',
    name: 'John',
  }
  
  // getter
  get idGetter() {
    return this.selectedUser.id;
  }
}
