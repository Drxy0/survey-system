import { Component, input, output } from '@angular/core';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-survey-question',
  imports: [
    MatRadioModule, 
    MatButtonModule, 
    MatInputModule,
    FormsModule
  ],
  templateUrl: './survey-question.component.html',
  styleUrl: './survey-question.component.css'
})
export class SurveyQuestionComponent {
  questionInput = input<string>();
  question: string | undefined = ("");
  
  index = input.required<number>();
  isCreatingSurvey = input<boolean>(false);

  questionChange = output<any>();
  
  ngOnInit() {
    this.question = this.questionInput();
  }

  onQuestionChange() {
    this.questionChange.emit({
        question: this.question,
        index: this.index()
      });
  }
}
