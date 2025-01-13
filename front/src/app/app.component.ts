import { Component } from '@angular/core';
import { HeaderComponent } from "./header/header.component";
import { UserProfileComponent } from "./user-profile/user-profile.component";

@Component({
  selector: 'app-root',
  imports: [HeaderComponent, UserProfileComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'front';
}
