import { Component, EventEmitter, Input, input, OnInit, Output } from '@angular/core';
import { User } from './user.model';
@Component({
  selector: 'app-user-profile',
  standalone: true,
  imports: [],
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent implements OnInit {
  user: User = {
    Name: "John",
    Surname: "Doe",
    Address: "123 Main St",
    City: "New York",
    Country: "USA",
    PhoneNumber: "+1 555-1234"
};

  ngOnInit(): void {
    // get current user from server
  }
}
