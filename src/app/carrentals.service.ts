import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { CarRentalsItems } from './carRentalsItems';

@Injectable({
  providedIn: 'root'
})
export class CarRentalsService {
  httpClient=inject(HttpClient);

  constructor() { }

  getAll(){
    return this.httpClient.get<CarRentalsItems[]>("https://localhost:7128/api/Rental/GetAll");
  }

  getByID(id:number){ 
    return this.httpClient.get<CarRentalsItems>("https://localhost:7128/api/Rental/GetByID/"+id); 
  }; 
  edit(item:CarRentalsItems){ 
    return this.httpClient.put("https://localhost:7128/api/Rental/Update", item);   
  }; 
  delete(id:number){ 
    return this.httpClient.delete("https://localhost:7128/api/Rental/Delete/"+id); 
  }; 
  create(item:CarRentalsItems){ 
    return this.httpClient.post<CarRentalsItems>("https://localhost:7128/api/Rental/Create", item); 
  }; 
  getAllCategories(){ 
    return this.httpClient.get<CarRentalsItems[]>("https://localhost:7128/api/Category") 
  }; 
}
