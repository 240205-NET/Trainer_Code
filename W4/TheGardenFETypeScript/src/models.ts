export interface Plant {
    plantID? : number
    commonName : string
    scientificName : string
    size : number
    zone : number
    adoptionDate : Date | string //union type
}