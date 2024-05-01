import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import {IApplication} from "../Interfaces/IApplication"
import { Observable, catchError } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class ApplicationService 
{
    http = inject(HttpClient)

    SaveApplicationDetails(ApplicationText:IApplication): Observable<any>
    {
        return this.http.post<any>('https://localhost:7072/Application/Create', ApplicationText )
        .pipe(
            catchError(err=>{
                console.error(err)
                throw err
            })
        )
    }
}