import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '@/_models';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {
  formData: Customer;
  customersList: Customer[];

  constructor(private http: HttpClient) { }

  addCustomer() {
    return this.http.post(`${config.apiUrl}/api/Customers`, this.formData);
  }

  updateCustomer() {
    return this.http.put(`${config.apiUrl}/api/Customers/` + this.formData.id, this.formData);
  }

  deleteCustomer(id) {
    return this.http.delete(`${config.apiUrl}/api/Customers/` + id);
  }

  getCustomers() {
    return this.http.get(`${config.apiUrl}/api/Customers`)
      .toPromise()
      .then(res => this.customersList = res as Customer[]);
  }
}
