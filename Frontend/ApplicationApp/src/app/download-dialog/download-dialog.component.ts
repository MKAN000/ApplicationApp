import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-download-dialog',
  standalone: true,
  imports: [MatDialogModule,MatButtonModule],
  templateUrl: './download-dialog.component.html',
  styleUrl: './download-dialog.component.css'
})
export class DownloadDialogComponent {
  constructor(public dialogRef: MatDialogRef<DownloadDialogComponent>) { }

  onNoClick(): void {
    
  }
  download(){
    console.log("pobrane")
    this.dialogRef.close();
  }
  cancel(){
    console.log("anulowane")
    this.dialogRef.close();
  }
}
