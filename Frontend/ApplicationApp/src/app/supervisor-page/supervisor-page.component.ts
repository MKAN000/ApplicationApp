import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApplicantService } from '../Services/applicant.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ISupervisor } from '../Interfaces/ISupervisor';
import { supervisorOrderService } from '../Services/supervisorOrder.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-supervisor-page',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './supervisor-page.component.html',
  styleUrl: './supervisor-page.component.css'
})
export class SupervisorPageComponent implements OnInit {
  form! : FormGroup
  isReadOnly: boolean = false;
  supervisorOrderDetails! : ISupervisor 

  /**
   *
   */
  constructor
  (
    private supervisorOrderService: supervisorOrderService,
    private route: ActivatedRoute,
    private fb:FormBuilder
    ) 
  {}


  ngOnInit(): void {
    this.initializeForm();
  }
  
  initializeForm(): void {
    this.form = this.fb.group({
      supervisorRank: ['', Validators.required],
      origin: ['', Validators.required],
      orderNo: ['', Validators.required],
      orderDate: ['', Validators.required]
    });
  }

  submitForm(): void{

    if(this.form?.valid)
    {
      this.supervisorOrderDetails = this.form.value

      this.supervisorOrderService.setOrderNo(this.form.value.orderNo)

      this.supervisorOrderService.SaveOrderDetails(this.supervisorOrderDetails)
      .subscribe({
        next(res) {
          console.log(res)
        },
        error(err) {
          console.log(err)
        },
      })

      this.isReadOnly = true;

    }
    else
    {
        console.log("form not valid")
        
    }
  }

  enableEdit(): void {
    this.isReadOnly = false; // Włączamy edycję pól formularza
  }
}
