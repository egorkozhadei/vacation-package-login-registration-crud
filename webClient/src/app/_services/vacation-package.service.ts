import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VacationPackage } from '@/_models';


@Injectable({
  providedIn: 'root'
})
export class VacationPackagesService {
  formData: VacationPackage;
  vacationPackagesList: VacationPackage[];

  constructor(private http: HttpClient) { }

  addVacationPackage() {
    return this.http.post(`${config.apiUrl}/api/VacationPackage`, this.formData);
  }

  updateVacationPackage() {
    return this.http.put(`${config.apiUrl}/api/VacationPackage/` + this.formData.id, this.formData);
  }

  deleteVacationPackage(id) {
    return this.http.delete(`${config.apiUrl}/api/VacationPackage/` + id);
  }

  getVacationPackages() {
    return this.http.get(`${config.apiUrl}/api/VacationPackage`)
      .toPromise()
      .then(res => this.vacationPackagesList = res as VacationPackage[]);
  }
}
