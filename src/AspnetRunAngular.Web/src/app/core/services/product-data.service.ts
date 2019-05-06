import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
// import { IAppointmentsSearchArgs, IAppointment, IPage } from 'src/app/shared/interfaces';
import { environment } from 'src/environments/environment';

@Injectable()
export class ProductDataService {
    constructor(private httpClient: HttpClient) { }

    // filterAppointments(args: IAppointmentsSearchArgs): Observable<IPage<IAppointment>> {
    //     var request = { searchArgs: args };

    //     return this.httpClient.post<IPage<IAppointment>>(environment.apiUrl + '/product/FilterAppointments', request);
    // }

    // getAppointmentById(id: string): Observable<IAppointment> {
    //     var request = { id: id };

    //     return this.httpClient.post<IAppointment>(environment.apiUrl + '/product/GetAppointmentById', request);
    // }
}
