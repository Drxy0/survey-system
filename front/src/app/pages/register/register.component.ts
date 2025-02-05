import { Component, signal } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

function equalValues(inName1: string, inName2: string) {
  return (control: AbstractControl) => {
    const in1 = control.get(inName1)?.value;
    const in2 = control.get(inName2)?.value;

    if (in1 !== in2) {
      return { valuesNotEqual: true };
    }

    return null;
  };
}

function containsNonNumericSymbols(control: AbstractControl) {
  if (control.value.match(/^\+[0-9]+$/)) {
    return { doesNotContainInvalidCharacters: true };
  }

  return null;
}

@Component({
  selector: 'app-register',
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    CommonModule,
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  form = new FormGroup({
    name: new FormControl('', {
      validators: [Validators.required],
    }),
    surname: new FormControl('', {
      validators: [Validators.required],
    }),
    address: new FormControl(),
    city: new FormControl(),
    country: new FormControl(),
    phoneNumber: new FormControl('', {
      validators: [containsNonNumericSymbols],
    }),
    email: new FormControl('', {
      validators: [Validators.email, Validators.required],
    }),
    passwords: new FormGroup(
      {
        password: new FormControl('', {
          validators: [Validators.minLength(6), Validators.required],
        }),
        confirmPassword: new FormControl('', {
          validators: [Validators.minLength(6), Validators.required],
        }),
      },
      {
        validators: [equalValues('password', 'confirmPassword')],
      }
    ),
  });

  onSubmit() {
    console.log(this.form.controls.passwords.errors?.['valuesNotEqual']);
    console.log(this.form.get('passwords')?.hasError('valuesNotEqual'));
  }
}
