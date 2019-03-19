import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-Employee',
  templateUrl: './Employee.component.html',
  styleUrls: ['./Employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employees: any;

  constructor(private http: HttpClient) { }

  ngOnInit()
   {
    this.getEmployees();
   }

getEmployees()
{
  this.http.get('http://localhost:5000/api/Employees').subscribe(response => {
    this.employees = response;
  }, error => {
    console.log(error);
  } );
}
}
