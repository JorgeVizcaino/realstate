import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HousesModel } from '../models/hause.model';

@Injectable({
    providedIn: 'root'
})
export class HauseService {

    private baseUrl = environment.apiBaseUrl;
    constructor(private http: HttpClient) { }

    getHauseSummary(): Observable<HousesModel[]> {
        return this.http
            .get<HousesModel[]>(`${this.baseUrl}/Hauses/getSummary`)
            .pipe(catchError(err => {
                throw err;
            }));
    }
}
