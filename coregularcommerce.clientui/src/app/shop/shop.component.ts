import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/modules/brand';
import { IPagination } from '../shared/modules/pagination';
import { IProduct } from '../shared/modules/product';
import { IProductType } from '../shared/modules/productType';
import { ShopParams } from '../shared/modules/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: false})searchTerm?:ElementRef;
  products: IProduct[] = [];
  brands: IBrand[] = [];
  productTypes: IProductType[] = [];
  shopParams: ShopParams = new ShopParams();
  totalCount: number = 0;
  sortOptions = [
    {name: 'Alfabetik', value: 'name'},
    {name: 'Fiyata Göre Artan', value: 'priceAsc'},
    {name: 'Fiyata Göre Azalan', value: 'priceDesc'},
    {name: 'Markaya Göre A-Z', value: 'brandAsc'},
    {name: 'Markaya Göre Z-A', value: 'brandDesc'},
    {name: 'Ürün Türüne Göre A-Z', value: 'productTypeAsc'},
    {name: 'Ürün Türüne Göre Z-A', value: 'productTypeDesc'},
  ];


  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
      this.getBrands();
      this.getProductTypes();
      this.getProducts();
  }

  private getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe((response : IPagination | null) => {
      if(response != null) {
        this.products = response.data;
        this.shopParams.pageNumber = response.pageIndex;
        this.shopParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      }
    }, (error) => {
      console.error(error);
    });
  }

  private getBrands() {
    this.shopService.getBrands().subscribe((response: IBrand[]) => {
      this.brands = [{id:null, name:'Tümü'}, ...response]
    }, (error) => {
      console.error(error);
    });
  }

  private getProductTypes () {
    this.shopService.getProductTypes().subscribe((response : IProductType[]) => {
      this.productTypes = [{id:null, name: 'Tümü'}, ...response];
    }, (error) => {
      console.error(error);
    });
  }

  onBrandSelected(brandId: number|null) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onProductTypeSelected(productTypeId: number|null) {
    this.shopParams.productTypeId = productTypeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string|null) {
    this.shopParams.sort = sort;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if(this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTerm?.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset() {
    this.searchTerm!.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }

}
