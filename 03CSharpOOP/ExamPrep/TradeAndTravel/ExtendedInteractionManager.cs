using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    class ExtendedInteractionManager : InteractionManager
    {
        // Methods
        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "shopkeeper":
                case "traveller":
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                        break;
                default:
                    break;
            }

            return person;
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "armor":
                    {
                        item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                        break;
                    }
                case "weapon":
                    {
                        item = new Weapon(itemNameString, itemLocation);
                        break;
                    }
                case "wood":
                    {
                        item = new Wood(itemNameString, itemLocation);
                        break;
                    }
                case "iron":
                    {
                        item = new Iron(itemNameString, itemLocation);
                        break;
                    }
                default:
                    break;
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "town":
                    {
                        location = base.CreateLocation(locationTypeString, locationName);
                        break;
                    }
                case "mine":
                    {
                        location = new Mine(locationName);
                        break;
                    }
                case "forest":
                    {
                        location = new Forest(locationName);
                        break;
                    }
                default:
                    break;
            }

            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "drop":
                case "pickup":
                case "sell":
                case "buy":
                case "inventory":
                case "money":
                case "travel":
                    {
                        base.HandlePersonCommand(commandWords, actor);
                        break;
                    }
                case "gather":
                    {
                        HandleGatherInteraction(commandWords, actor);
                        break;
                    }
                case "craft":
                    {
                        HandleCraftInteraction(commandWords, actor);
                        break;
                    }
                default:
                    break;
            }
            
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            List<Item> actorsItems = actor.ListInventory();
            bool hasWood = false;
            bool hasIron = false;

            foreach (var item in actorsItems)
            {
                if (item.ItemType == ItemType.Iron)
                {
                    hasIron = true;
                }
                else if (item.ItemType == ItemType.Wood)
                {
                    hasWood = true;
                }
            }

            if (commandWords[2] == "armor" && hasIron)
            {
                this.AddToPerson(actor, new Armor(commandWords[3]));
                //actor.AddToInventory(new Armor(commandWords[3]));
            }
            else if (commandWords[2] == "weapon" && hasIron && hasWood)
            {
                this.AddToPerson(actor, new Weapon(commandWords[3]));
                //actor.AddToInventory(new Weapon(commandWords[3]));
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            List<Item> actorsItems = actor.ListInventory();

            foreach (var item in actorsItems)
            {
                if (item.ItemType == ItemType.Weapon && actor.Location.LocationType == LocationType.Forest)
                {
                    this.AddToPerson(actor, new Wood(commandWords[2]));
                    //actor.AddToInventory(new Wood(commandWords[2]));
                }
                else if (item.ItemType == ItemType.Armor && actor.Location.LocationType == LocationType.Mine)
                {
                    this.AddToPerson(actor, new Iron(commandWords[2]));
                    //actor.AddToInventory(new Iron(commandWords[2]));
                }
            }
        }
    }
}
