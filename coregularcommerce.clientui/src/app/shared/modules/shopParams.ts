export class ShopParams {
  brandId: number|null = null;
  productTypeId: number|null = null;
  sort: string|null = 'name';
  pageNumber: number = 1;
  pageSize: number = 6;
  search?: string;
}
