import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { ApplicantService } from '../Services/applicant.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-page',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.css'
})

export class MainPageComponent {
  myForm: FormGroup;

  constructor
  (
    private fb: FormBuilder,
    private applicantService : ApplicantService,
    private router: Router
    
  )
  {
    this.myForm = this.fb.group({
      inputData : [' ', Validators.required]
    })
    
  }

  GetApplicantDataFromForm()
  {
    const albumNumber = this.myForm.get('inputData')?.value;
    this.router.navigateByUrl(`/application/${albumNumber}`)
  }

  
}
