import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {
  baseUrl: string = `${environment.apiUrl}`;
  validationErrors: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  get404NotFound() {
    this.http.get(`${this.baseUrl}Product/102`).subscribe((res) => {
      console.log("Yanıt: ", res)
    }, (err) => {
      console.warn("Hata: ", err);
    });
  }

  get500ServerError() {
    this.http.get(`${this.baseUrl}Buggy/ServerError`).subscribe((res) => {
      console.log("Yanıt: ", res)
    }, (err) => {
      console.warn("Hata: ", err);
    });
  }

  get400BadRequest() {
    this.http.get(`${this.baseUrl}Buggy/BadRequestError`).subscribe((res) => {
      console.log("Yanıt: ", res)
    }, (err) => {
      console.warn("Hata: ", err);
    });
  }

  get400BadRequestValidation() {
    this.http.get(`${this.baseUrl}Product/asdasd`).subscribe((res) => {
      console.log("Yanıt: ", res)
    }, (err) => {
      this.validationErrors = err.errors;
      console.warn("Hata: ", err);
    });
  }
}
