import { Component } from '@angular/core';
import { HeaderComponent } from "./header/header.component";
import { UserProfileComponent } from "./user-profile/user-profile.component";
import { LoginComponent } from "./pages/login/login.component";
import { SurveyQuestionComponent } from "./pages/create-survey/survey-question/survey-question.component";
import { CreateSurveyComponent } from "./pages/create-survey/create-survey.component";

@Component({
  selector: 'app-root',
  imports: [HeaderComponent, UserProfileComponent, LoginComponent, SurveyQuestionComponent, CreateSurveyComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'front';
}
