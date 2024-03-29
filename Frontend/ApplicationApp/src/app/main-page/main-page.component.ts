import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { ApplicantService } from '../Services/applicant.service';

@Component({
  selector: 'app-main-page',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.css'
})

export class MainPageComponent {
  myForm: FormGroup;
  rank: String ="";
  name: String ="";
  surname: String ="";
  facultyGroup: String =""
  subdivision: String =""
  albumNumber: String =""

  

  constructor
  (
    private fb: FormBuilder,
    private applicantService : ApplicantService,
    
  )
  {
    this.myForm = this.fb.group({
      inputData : [' ', Validators.required]
    })
    
  }

  GetApplicantDataFromForm()
  {
    const inputData = this.myForm.get('inputData')?.value;
    console.log(inputData);
    this.GetApplicantDataFromServer(inputData)
  }

  GetApplicantDataFromServer(albumNumber : Number):void{
    this.applicantService.GetApplicantData(albumNumber)
      .subscribe((data)=>{
        this.rank = data.rank;
        this.name = data.name;
        this.surname = data.surname;
        this.facultyGroup = data.facultyGroup;
        this.subdivision = data.subdivision;
        this.albumNumber = data.albumNumber;
        console.log(data);
      })
  }
}
