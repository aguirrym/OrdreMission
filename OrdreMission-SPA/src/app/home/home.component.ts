import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
registerMode = false;

employees: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEmployees();
  }

  registerToggle() {
  this.registerMode = true;
  }
   getEmployees() {
    this.http.get('http://localhost:5000/api/Employees').subscribe(response => {
     this.employees = response;
     }, error => {
    console.log(error);
    } );
   }

  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }
}
