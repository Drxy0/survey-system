import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { NgIcon, provideIcons } from '@ng-icons/core';
import { matPlusOutline, matMinusOutline } from '@ng-icons/material-icons/outline';
import { SurveyQuestionComponent } from './survey-question/survey-question.component';

interface Question {
  index: number;
  question: string;
}

@Component({
  selector: 'app-create-survey',
  standalone: true,
  imports: [
    SurveyQuestionComponent,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    NgIcon
  ],
  templateUrl: './create-survey.component.html',
  styleUrls: ['./create-survey.component.css'],
  viewProviders: [provideIcons({ matPlusOutline, matMinusOutline })]
})
export class CreateSurveyComponent implements OnInit {
  questions: Question[] = [];

  ngOnInit() {
    this.loadQuestionsFromLocalStorage();
  }
  
  loadQuestionsFromLocalStorage() {
    let index = 0;
    let question: string | null;
    while ((question = localStorage.getItem(`question_${index}`)) !== null) {
      this.questions.push({ index, question });
      index++;
    }
    if (this.questions.length === 0) {
      this.addEmptyQuestion(); // Initialize with one empty question if none exist
    }
  }

  addEmptyQuestion() {
    this.questions.push({ index: 0, question: '' });
    this.saveQuestionToLocalStorage(0, ''); // Save the empty question
  }
  
  onAddQuestion() {
    const newIndex = this.questions.length;
    this.questions.push({ index: newIndex, question: '' });
    this.saveQuestionToLocalStorage(newIndex, ''); // Save the new empty question
  }

  onDeleteQuestion() {
    if (this.questions.length === 1) return
    this.questions.pop();
    localStorage.removeItem(`question_${this.questions.length}`)
  }

  onQuestionChange(event: { question: string; index: number }) {
    this.questions[event.index].question = event.question;
    this.saveQuestionToLocalStorage(event.index, event.question); // Save the updated question
  }

  saveQuestionToLocalStorage(index: number, question: string) {
    localStorage.setItem(`question_${index}`, question);
  }

  onCreateSurvey() {

  }
}
