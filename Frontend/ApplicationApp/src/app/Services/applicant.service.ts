import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable , inject} from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class ApplicantService
{
    http = inject(HttpClient)

    GetApplicantData(number : Number) : Observable<any>
    {
        const headers = new HttpHeaders({
            'Content-Type' : 'application/json',
            'albumNumber' : number.toString()
    
        });
    
        const options = {
            headers : headers
        }
        return this.http.get<any>('https://localhost:7072/Applicant/Get', options)
    }
}