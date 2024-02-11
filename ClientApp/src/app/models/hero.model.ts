export interface Hero {
    Id?: number,
    Name: string,
    Alias: string,
    BrandId: number,
    Brand?: Brand
}

export interface Brand {
    Id: number,
    Name: string
}