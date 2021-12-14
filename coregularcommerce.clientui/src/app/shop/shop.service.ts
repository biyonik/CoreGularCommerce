import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { IBrand } from '../shared/modules/brand';
import { IPagination } from '../shared/modules/pagination';
import { IProductType } from '../shared/modules/productType';
import { ShopParams } from '../shared/modules/shopParams';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl: string = 'https://localhost:7012/api/';

  constructor(private http: HttpClient) {}

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();
    if(shopParams.brandId != null) {
      params = params.append('brandId', shopParams.brandId.toString());
    }
    if(shopParams.productTypeId != null) {
      params = params.append('productTypeId', shopParams.productTypeId.toString());
    }
    if(shopParams.sort) {
      params = params.append('sort', shopParams.sort);
    }
    params = params.append('pageIndex', shopParams.pageNumber);
    params = params.append('pageSize', shopParams.pageSize);
    if(shopParams.search != null) {
      params = params.append('search', shopParams.search);
    }

    return this.http.get<IPagination>(`${this.baseUrl}Product`, {observe: 'response', params}).pipe(
      map(response => {
        return response.body;
      })
    )
  }

  getBrands() {
    return this.http.get<IBrand[]>(`${this.baseUrl}Brand`);
  }

  getProductTypes() {
    return this.http.get<IProductType[]>(`${this.baseUrl}ProductType`);
  }
}
