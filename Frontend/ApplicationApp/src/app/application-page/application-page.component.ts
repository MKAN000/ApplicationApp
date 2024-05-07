import { Component, OnInit } from '@angular/core';
import { ApplicantService } from '../Services/applicant.service';
import { ActivatedRoute } from '@angular/router';
import { SupervisorPageComponent } from '../supervisor-page/supervisor-page.component';
import { ApplicationTextComponent } from '../application-text/application-text.component';
import { MatDialog } from '@angular/material/dialog';
import { DownloadDialogComponent } from '../download-dialog/download-dialog.component'


@Component({
  selector: 'app-application-page',
  standalone: true,
  imports: [SupervisorPageComponent,ApplicationTextComponent],
  templateUrl: './application-page.component.html',
  styleUrl: './application-page.component.css'
})
export class ApplicationPageComponent implements OnInit{
  rank: String ="";
  name: String ="";
  surname: String ="";
  facultyGroup: String =""
  subdivision: String =""
  albumNumber: Number = 0
  
  

  constructor(private applicantService : ApplicantService,private route: ActivatedRoute,public dialog: MatDialog)
  {
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(DownloadDialogComponent, {
      width: '250px',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('Dialog został zamknięty');
    });
  }
  ngOnInit(): void {
    const albumNumber = this.route.snapshot.paramMap.get('albumNumber')

    if (albumNumber !== null && albumNumber !== undefined) {
      this.albumNumber = parseInt(albumNumber);
      this.GetApplicantDataFromServer(this.albumNumber)
    }
    else
    {
      console.log("album Number is undefinded")
    }
}

  GetApplicantDataFromServer(albumNumber : Number):void{
    this.applicantService.GetApplicantData(albumNumber)
      .subscribe((data)=>{
        this.rank = data.rank;
        this.name = data.name;
        this.surname = data.surname;
        this.facultyGroup = data.facultyGroup;
        this.subdivision = data.subdivision;
        console.log(data);
      })
  }
}
