import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-application-text',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './application-text.component.html',
  styleUrl: './application-text.component.css'
})
export class ApplicationTextComponent implements OnInit {
  myForm! : FormGroup
  isReadOnly: boolean = false;
  
  /**
   *
   */
  constructor(private formBuilder: FormBuilder) {
    
  }
  ngOnInit(): void {
    this.myForm = this.formBuilder.group({
      applicationPurpose: [''],
      toWhom: [''],
      dateRange: [''],
      reason: [''],
      isOnDuty: [false],
      isHavingClasses: [false],
      arrears: [''],
      isHavingDisciplinaryPenalty: [false],
      vacDestination: ['']
    });
  }
  onSubmit() {
    console.log(this.myForm.value);
    this.isReadOnly = true;
  }
  enableEdit(): void {
    this.isReadOnly = false; 
  }
}
