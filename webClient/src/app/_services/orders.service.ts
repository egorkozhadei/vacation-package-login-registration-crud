import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order, OrderDto } from '@/_models';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  formData: OrderDto;
  ordersList: Order[];

  constructor(private http: HttpClient) { }

  addOrder() {
    return this.http.post(`${config.apiUrl}/api/Orders`, this.formData);
  }

  updateOrder() {
    return this.http.put(`${config.apiUrl}/api/Orders/` + this.formData.id, this.formData);
  }

  deleteOrder(id) {
    return this.http.delete(`${config.apiUrl}/api/Orders/` + id);
  }

  getOrders() {
    return this.http.get(`${config.apiUrl}/api/Orders`)
      .toPromise()
      .then(res => {
            this.ordersList = res as Order[];
            console.log(res);
          }
        );
  }
}
