
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Component, OnInit, inject } from '@angular/core';import { CarRentalsService } from '../../carrentals.service';
import { FormsModule } from '@angular/forms';import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';import { ActivatedRoute, Router } from '@angular/router';
import { CarRentalsItems } from '../../carRentalsItems';
function findIndexByID(jsonArray: any[], indexToFind: number): number {  return jsonArray.findIndex((item) => item.id === indexToFind);
}
@Component({  selector: 'app-edit',
  standalone: true,  imports: [FormsModule, MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule],
  templateUrl: './edit.component.html',  styleUrl: './edit.component.css'
})
export class EditComponent implements OnInit {  CarRentalsService = inject(CarRentalsService); // Service to get and send data from and to the API
  activatedRoute = inject(ActivatedRoute);  router = inject(Router);
  editRecipe: CarRentalsItems = {    
    id: 0,
    userName: "",    
    description: "",
    categoryID: 0,    
    category: {
      id: 0,      
      name: ""
    }  };
  categoryObject: any; 
   selected: any 
  cID: number = 0; 
   ngOnInit() {
    this.CarRentalsService.getByID(this.activatedRoute.snapshot.params["id"]).subscribe(result => {      this.editRecipe = result;
      this.selected = this.editRecipe.categoryID;    });
    this.CarRentalsService.getAllCategories().subscribe((result) => {      this.categoryObject = result;
    });  }
  toHome() {
    this.router.navigateByUrl("home")  }
  edit() {
    this.editRecipe.categoryID = this.cID;    this.editRecipe.category = this.categoryObject[findIndexByID(this.categoryObject, this.cID)];
    this.CarRentalsService.edit(this.editRecipe).subscribe(res=>{      alert("Changes has been updated")
      this.router.navigateByUrl("home");    })
  }}

