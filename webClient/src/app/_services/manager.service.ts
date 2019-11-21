import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Manager } from '@/_models';

@Injectable({ providedIn: 'root' })
export class ManagerService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<Manager[]>(`${config.apiUrl}/managers`);
    }

    register(user: Manager) {
        return this.http.post(`${config.apiUrl}/managers/register`, user);
    }

    delete(id: number) {
        return this.http.delete(`${config.apiUrl}/managers/${id}`);
    }
}