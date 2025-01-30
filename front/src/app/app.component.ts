import { Component } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { LoginComponent } from './pages/login/login.component';
import { CreateSurveyComponent } from './pages/create-survey/create-survey.component';
import { RegisterComponent } from './pages/register/register.component';

@Component({
  selector: 'app-root',
  imports: [
    HeaderComponent,
    UserProfileComponent,
    LoginComponent,
    CreateSurveyComponent,
    RegisterComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'front';
}
