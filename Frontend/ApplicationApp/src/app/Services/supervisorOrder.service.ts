import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable , inject} from "@angular/core";
import { Observable, catchError } from "rxjs";
import { ISupervisor } from "../Interfaces/ISupervisor";

@Injectable({
    providedIn: 'root'
})

export class supervisorOrderService
{
    http = inject(HttpClient)

    SaveOrderDetails(supervisorOrderDetails:ISupervisor) : Observable<any>
    {
       return this.http.post<any>('https://localhost:7072/Supervisor/Create', supervisorOrderDetails)
       .pipe(
        catchError(err=>{
            console.error("404 Bad Request", err)
            throw err
        })
       )
    }
}