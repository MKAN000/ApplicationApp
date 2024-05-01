import { CommonModule } from '@angular/common';
import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ApplicationService } from '../Services/application.service';
import { IApplication } from '../Interfaces/IApplication';
import { supervisorOrderService } from '../Services/supervisorOrder.service';


@Component({
  selector: 'app-application-text',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,],
  templateUrl: './application-text.component.html',
  styleUrl: './application-text.component.css'
})
export class ApplicationTextComponent implements OnInit {
  myForm! : FormGroup
  isReadOnly: boolean = false;
  applicationText! : IApplication
  @Input() albumNumber! : Number
  
  /**
  ///////////
   */
  constructor(
    private formBuilder: FormBuilder,
    private applicationService: ApplicationService,
    private supervisorOrderService : supervisorOrderService
  ) {
    
  }
  ngOnInit(): void {
    console.log(this.albumNumber)
    this.myForm = this.formBuilder.group({
      applicationPurpose: [''],
      toWhom: [''],
      startDate: [''],
      endDate: [''],
      reason: [''],
      isOnDuty: [false],
      isHavingClasses: [false],
      arrears: [''],
      isHavingDisciplinaryPenalty: [false],
      vacDestination: ['']
    });
  }
  onSubmit() {
    if(this.myForm?.valid)
    {
      this.applicationText = this.myForm.value

      this.applicationText.ApplicantModelAlbumNumber = this.albumNumber.toString()

      this.applicationText.SupervisorModelOrderNo = this.supervisorOrderService.getOrderNo();

      console.log(this.applicationText)

      this.applicationService.SaveApplicationDetails(this.applicationText)
      .subscribe({
        next(res) 
        {
          console.log(res)
        },
        error(err)
        {
          console.log(err)
        }
      })
      this.isReadOnly = true;
    }
    else
    {
      console.log("form not valid")
    }
  }
  enableEdit(): void {
    this.isReadOnly = false; 
  }
}
