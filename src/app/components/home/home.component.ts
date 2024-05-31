import { Component, Input, inject } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { CarRentalsService } from '../../carrentals.service';
import { CarRentalsItems } from '../../carRentalsItems';
import { Router } from '@angular/router';



@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatTableModule, MatButtonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  router = inject(Router)
  items:CarRentalsItems[]=[];
  carRentalsService = inject(CarRentalsService);
  ngOnInit(){
    this.carRentalsService.getAll().subscribe((result)=>{
      this.items = result;
    });
  }

  displayedColumns: string[] = ['ID', 'User Name', 'Description', 'Category Name', 'Actions'];

  onCreate(){
    console.log("Oncreate Clicked")
    this.router.navigateByUrl("/create")
  }
  onEdit(id:number){
    console.log("Edit: ", id)
    this.router.navigateByUrl("/edit/"+id)
  }
  onDetails(id:number){
    console.log("onDetails: ", id)
    this.router.navigateByUrl("/details/"+id)
  }
  onDelete(id:number){
    console.log("onDelete: ", id)
    this.router.navigateByUrl("/delete/"+id)
  }
}
