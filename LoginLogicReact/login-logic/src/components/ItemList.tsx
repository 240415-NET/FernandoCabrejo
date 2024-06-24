import React from 'react'

interface Item {
    userId: string;
    itemId: string;
    category: string;
    originalCost: number;
    purchaseDate: Date;
    description: string;
}

interface ItemListProps {
    itemsFromUserInfo: Item[];
}

function ItemList({itemsFromUserInfo}: ItemListProps) {

    return (
    <div>ItemList</div>
  )
}

export default ItemList