using GenericRepository.Tests.Infrastructure;
using GenericRepository.Tests.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable StringLiteralTypo

namespace GenericRepository.Tests.TestHelpers;

public static class DatabaseInitializer
{
    public static TestsDbContext InitDatabaseWithExampleData()
    {
        var db = GetMemoryContext();

        if (!db.Database.IsInMemory())
        {
            throw new InvalidOperationException("Tests must be running with in-memory database");
        }

        db.Database.EnsureDeleted();

        db.Companies.AddRange(new Company
            {
                Name = "Apple Inc.",
                FoundedLocation = "Los Altos, California, U.S.",
                Industry = "Consumer electronics",
                Departments = new()
                {
                    new()
                    {
                        Name = "Apple Sales",
                        HeadOfDepartment = new()
                        {
                            FirstName = "Chester",
                            LastName = "Koelpin"
                        },
                        Managers = new()
                        {
                            new()
                            {
                                FirstName = "Elijah",
                                LastName = "Cassin",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Apple Sales Team 1",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Gerardo",
                                                    LastName = "Orn"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Nelson",
                                                    LastName = "Nolan"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Guy",
                                                    LastName = "Douglas"
                                                },
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Apple Sales Team 2",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Sherman",
                                                    LastName = "Turner"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Blake",
                                                    LastName = "Koepp"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Theodore",
                                                    LastName = "Botsford"
                                                },
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Lynn",
                                LastName = "Cruickshank",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Apple Sales Team 3",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Joe",
                                                    LastName = "Smitham"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Donald",
                                                    LastName = "Turcotte"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Kent",
                                                    LastName = "Reichel"
                                                },
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Apple Sales Team 4",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Sherman",
                                                    LastName = "Turner"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Blake",
                                                    LastName = "Koepp"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Theodore",
                                                    LastName = "Botsford"
                                                },
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Emanuel",
                                LastName = "Runolfsdottir",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Apple Sales Team 5",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Leslie",
                                                    LastName = "Powlowski"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Ricky",
                                                    LastName = "Bernier"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Winston",
                                                    LastName = "Balistreri"
                                                },
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Apple Sales Team 6",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Sherman",
                                                    LastName = "Turner"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Blake",
                                                    LastName = "Koepp"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Theodore",
                                                    LastName = "Botsford"
                                                },
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    },
                    new()
                    {
                        Name = "Apple IT",
                        HeadOfDepartment = new()
                        {
                            FirstName = "Phillip",
                            LastName = "Ondricka"
                        },
                        Managers = new()
                        {
                            new()
                            {
                                FirstName = "Eddie",
                                LastName = "Hilpert",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Apple IT Team 1>",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Alfredo",
                                                    LastName = "Bogisich"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Jessie",
                                                    LastName = "Monahan"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Albert",
                                                    LastName = "Nikolaus"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Apple IT Team 2",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Tim",
                                                    LastName = "Runolfsdottir"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Evan",
                                                    LastName = "Bergstrom"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Felix",
                                                    LastName = "Marks"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Salvador",
                                LastName = "Dietrich",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Apple IT Team 3",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Christopher",
                                                    LastName = "Corkery"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Aubrey",
                                                    LastName = "Schimmel"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Herman",
                                                    LastName = "Mitchell"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Apple IT Team 4",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Neil",
                                                    LastName = "Towne"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Timmy",
                                                    LastName = "Pollich"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Everett",
                                                    LastName = "Gottlieb"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Neil",
                                LastName = "Becker",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Apple IT Team 5",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Gordon",
                                                    LastName = "Towne"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Floyd",
                                                    LastName = "Cummerata"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Spencer",
                                                    LastName = "Bosco"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Apple IT Team 6",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Neil",
                                                    LastName = "Trantow"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Nathan",
                                                    LastName = "Nicolas"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Dwayne",
                                                    LastName = "Batz"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Jack",
                                LastName = "Smith",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Apple IT Team 7",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Jaime",
                                                    LastName = "Kuphal"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Nathan",
                                                    LastName = "Marquardt"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Glenn",
                                                    LastName = "Langosh"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Apple IT Team 8",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Craig",
                                                    LastName = "McKenzie"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Casey",
                                                    LastName = "Leffler"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Leslie",
                                                    LastName = "Lebsack"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    },
                    new()
                    {
                        Name = "Apple R&D",
                        HeadOfDepartment = new()
                        {
                            FirstName = "David",
                            LastName = "Orn"
                        },
                        Managers = new()
                        {
                            new()
                            {
                                FirstName = "Edward",
                                LastName = "Zboncak",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "APPLE R&D Team 1",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Wesley",
                                                    LastName = "Tromp"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Terrance",
                                                    LastName = "Feil"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Geoffrey",
                                                    LastName = "Lubowitz"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "APPLE R&D Team 2",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Elbert",
                                                    LastName = "Rutherford"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Bradley",
                                                    LastName = "O'Connell"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Morris",
                                                    LastName = "Bartell"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Melvin",
                                LastName = "Wisoky",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "APPLE R&D Team 3",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Carroll",
                                                    LastName = "Daniel"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Steven",
                                                    LastName = "Berge"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Bradley",
                                                    LastName = "Renner"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "APPLE R&D Team 4",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Kelvin",
                                                    LastName = "Carroll"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Jackie",
                                                    LastName = "Kulas"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Dana",
                                                    LastName = "Lockman"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Timothy",
                                LastName = "Stark",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "APPLE R&D Team 5",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Sam",
                                                    LastName = "Gleason"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Tom",
                                                    LastName = "Ledner"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Roland",
                                                    LastName = "Luettgen"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "APPLE R&D Team 6",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Jan",
                                                    LastName = "Rosenbaum"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Ted",
                                                    LastName = "Swaniawski"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Cedric",
                                                    LastName = "Cole"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Tommie",
                                LastName = "Schumm",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "APPLE R&D Team 7",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Charles",
                                                    LastName = "Ullrich"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Casey",
                                                    LastName = "Schuppe"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Timmy",
                                                    LastName = "Bogisich"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "APPLE R&D Team 8",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Jody",
                                                    LastName = "Parker"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Lorenzo",
                                                    LastName = "Renner"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Alexander",
                                                    LastName = "Wuckert"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    },
                }
            },
            new Company
            {
                Name = "Google",
                FoundedLocation = "California, U.S.",
                Industry = "Computer software",
                Departments = new()
                {
                    new()
                    {
                        Name = "Google Sales",
                        HeadOfDepartment = new()
                        {
                            FirstName = "Jo",
                            LastName = "Runolfsson"
                        },
                        Managers = new()
                        {
                            new()
                            {
                                FirstName = "Brad",
                                LastName = "Wiza",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Google Sales Team 1",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Clint",
                                                    LastName = "Howell"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Shannon",
                                                    LastName = "Lowe"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Dominic",
                                                    LastName = "Krajcik"
                                                },
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Google Sales Team 2",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Floyd",
                                                    LastName = "Monahan"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Brendan",
                                                    LastName = "Yundt"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Milton",
                                                    LastName = "Bailey"
                                                },
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Malcolm",
                                LastName = "Gorczany",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Google Sales Team 3",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Marsha",
                                                    LastName = "Larkin"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Herman",
                                                    LastName = "Stamm"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Terrance",
                                                    LastName = "Lowe"
                                                },
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Google Sales Team 4",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Kendra",
                                                    LastName = "Robel"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Francis",
                                                    LastName = "Kerluke"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Melissa",
                                                    LastName = "Rau"
                                                },
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Max",
                                LastName = "Stehr",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Google Sales Team 5",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Roosevelt",
                                                    LastName = "Lubowitz"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Robin",
                                                    LastName = "Weissnat"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Nathan",
                                                    LastName = "Haley"
                                                },
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Google Sales Team 6",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Jaime",
                                                    LastName = "Gorczany"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Johnny",
                                                    LastName = "Murazik"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Tara",
                                                    LastName = "Connelly"
                                                },
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    },
                    new()
                    {
                        Name = "Google IT",
                        HeadOfDepartment = new()
                        {
                            FirstName = "Wm",
                            LastName = "Goodwin"
                        },
                        Managers = new()
                        {
                            new()
                            {
                                FirstName = "Kelley",
                                LastName = "Gleichner",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Google IT Team 1>",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Susan",
                                                    LastName = "Pollich"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Leroy",
                                                    LastName = "Mayert"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Terry",
                                                    LastName = "Bogisich"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Google IT Team 2",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Bill",
                                                    LastName = "Harris"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Dale",
                                                    LastName = "Turner"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Craig",
                                                    LastName = "Kunze"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Emma",
                                LastName = "Mills",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Google IT Team 3",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Wilma",
                                                    LastName = "Simonis"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Alicia",
                                                    LastName = "Brekke"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Colleen",
                                                    LastName = "Heidenreich"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Google IT Team 4",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Jerald",
                                                    LastName = "Nitzsche"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Essie",
                                                    LastName = "Koepp"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Clifford",
                                                    LastName = "Bartoletti"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Jamie",
                                LastName = "Nolan",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Google IT Team 5",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Jody",
                                                    LastName = "Orn"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Ernesto",
                                                    LastName = "Dietrich"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Leon",
                                                    LastName = "West"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Google IT Team 6",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Cecilia",
                                                    LastName = "Kunde"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Hazel",
                                                    LastName = "Lowe"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Krista",
                                                    LastName = "Beatty"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Jody",
                                LastName = "Nikolaus",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Google IT Team 7",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Theodore",
                                                    LastName = "Rodriguez"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Julius",
                                                    LastName = "Fahey"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Franklin",
                                                    LastName = "Berge"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Google IT Team 8",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Kate",
                                                    LastName = "Bernier"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Desiree",
                                                    LastName = "Hackett"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Brandy",
                                                    LastName = "Rice"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    },
                    new()
                    {
                        Name = "Google R&D",
                        HeadOfDepartment = new()
                        {
                            FirstName = "Mack",
                            LastName = "Sawayn"
                        },
                        Managers = new()
                        {
                            new()
                            {
                                FirstName = "Meredith",
                                LastName = "Schoen",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Google R&D Team 1",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Ernesto",
                                                    LastName = "Predovic"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Helen",
                                                    LastName = "Murphy"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Faith",
                                                    LastName = "Bosco"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Google R&D Team 2",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Bob",
                                                    LastName = "Reichert"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Van",
                                                    LastName = "Streich"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Hannah",
                                                    LastName = "Greenholt"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Lorenzo",
                                LastName = "Pagac",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Google R&D Team 3",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Mabel",
                                                    LastName = "Hahn"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Ben",
                                                    LastName = "Hettinger"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Julio",
                                                    LastName = "Willms"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Google R&D Team 4",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Nicolas",
                                                    LastName = "Pfeffer"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Kristopher",
                                                    LastName = "Ondricka"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Delbert",
                                                    LastName = "Hettinger"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Lila",
                                LastName = "Pacocha",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Google R&D Team 5",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Eleanor",
                                                    LastName = "Baumbach"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Alexander",
                                                    LastName = "Jaskolski"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Latoya",
                                                    LastName = "Turner"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Google R&D Team 6",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Eileen",
                                                    LastName = "Harvey"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Peter",
                                                    LastName = "Huel"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Forrest",
                                                    LastName = "Kihn"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Janice",
                                LastName = "Bednar",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Google R&D Team 7",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Frank",
                                                    LastName = "Brekke"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Sherman",
                                                    LastName = "Larson"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Alan",
                                                    LastName = "Swift"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Google R&D Team 8",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Clara",
                                                    LastName = "Witting"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Jaime",
                                                    LastName = "Altenwerth"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Eddie",
                                                    LastName = "Abshire"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    },
                }
            },
            new Company
            {
                Name = "Shell plc",
                FoundedLocation = "London, U.K.",
                Industry = "Energy",
                Departments = new()
                {
                    new()
                    {
                        Name = "Shell Sales",
                        HeadOfDepartment = new()
                        {
                            FirstName = "Stephen",
                            LastName = "Schoen"
                        },
                        Managers = new()
                        {
                            new()
                            {
                                FirstName = "Rita",
                                LastName = "Schiller",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Shell Sales Team 1",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Miriam",
                                                    LastName = "Jakubowski"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Tricia",
                                                    LastName = "Reichert"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Dixie",
                                                    LastName = "Jacobs"
                                                },
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Shell Sales Team 2",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Amanda",
                                                    LastName = "Hauck"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Clifton",
                                                    LastName = "Cummings"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Greg",
                                                    LastName = "Carter"
                                                },
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Manuel",
                                LastName = "Bahringer",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Shell Sales Team 3",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Gladys",
                                                    LastName = "Botsford"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Guadalupe",
                                                    LastName = "Lang"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Clinton",
                                                    LastName = "Lockman"
                                                },
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Shell Sales Team 4",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "William",
                                                    LastName = "Miller"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Edgar",
                                                    LastName = "Bogisich"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Merle",
                                                    LastName = "Denesik"
                                                },
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Miguel",
                                LastName = "Davis",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Shell Sales Team 5",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Emma",
                                                    LastName = "Hammes"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Don",
                                                    LastName = "Morar"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Mercedes",
                                                    LastName = "Rau"
                                                },
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Shell Sales Team 6",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Lorenzo",
                                                    LastName = "Mills"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Brittany",
                                                    LastName = "Simonis"
                                                },
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Karl",
                                                    LastName = "Little"
                                                },
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    },
                    new()
                    {
                        Name = "Shell IT",
                        HeadOfDepartment = new()
                        {
                            FirstName = "Grant",
                            LastName = "Herzog"
                        },
                        Managers = new()
                        {
                            new()
                            {
                                FirstName = "Jonathan",
                                LastName = "Thompson",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Shell IT Team 1>",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Alan",
                                                    LastName = "Bauch"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Eric",
                                                    LastName = "Nicolas"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Roger",
                                                    LastName = "Cormier"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Shell IT Team 2",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Faith",
                                                    LastName = "Howe"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Lynda",
                                                    LastName = "O'Connell"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Miguel",
                                                    LastName = "Goodwin"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Clarence",
                                LastName = "Ondricka",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Shell IT Team 3",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Delia",
                                                    LastName = "Hoppe"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Raymond",
                                                    LastName = "Rodriguez"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Tami",
                                                    LastName = "Quigley"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Shell IT Team 4",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Patricia",
                                                    LastName = "Schaefer"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Nancy",
                                                    LastName = "Walker"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Emmett",
                                                    LastName = "Halvorson"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Lois",
                                LastName = "Prosacco",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Shell IT Team 5",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Erik",
                                                    LastName = "Harber"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Carmen",
                                                    LastName = "Hoppe"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Jay",
                                                    LastName = "McLaughlin"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Shell IT Team 6",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Melinda",
                                                    LastName = "Altenwerth"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Simon",
                                                    LastName = "Kreiger"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Emanuel",
                                                    LastName = "Padberg"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "May",
                                LastName = "Reynolds",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Shell IT Team 7",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Dale",
                                                    LastName = "McGlynn"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Lowell",
                                                    LastName = "Gibson"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Theodore",
                                                    LastName = "Beatty"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Shell IT Team 8",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Alfonso",
                                                    LastName = "Mueller"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Whitney",
                                                    LastName = "Kovacek"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Curtis",
                                                    LastName = "Herman"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    },
                    new()
                    {
                        Name = "Shell R&D",
                        HeadOfDepartment = new()
                        {
                            FirstName = "Kirk",
                            LastName = "McClure"
                        },
                        Managers = new()
                        {
                            new()
                            {
                                FirstName = "Sylvester",
                                LastName = "Johnson",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Shell R&D Team 1",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Brent",
                                                    LastName = "Lang"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Arlene",
                                                    LastName = "Ward"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Stanley",
                                                    LastName = "Yost"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Shell R&D Team 2",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Darrel",
                                                    LastName = "Carter"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Dewey",
                                                    LastName = "Rosenbaum"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Roberta",
                                                    LastName = "Hegmann"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Ira",
                                LastName = "Stracke",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Shell R&D Team 3",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Marcella",
                                                    LastName = "Davis"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Lamar",
                                                    LastName = "Bins"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Brian",
                                                    LastName = "Lueilwitz"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Shell R&D Team 4",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Roy",
                                                    LastName = "Murray"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Kim",
                                                    LastName = "Kozey"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Herman",
                                                    LastName = "Hintz"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Hope",
                                LastName = "Daugherty",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Shell R&D Team 5",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Paula",
                                                    LastName = "Wyman"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Phillip",
                                                    LastName = "Runolfsson"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Stuart",
                                                    LastName = "Lueilwitz"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Shell R&D Team 6",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Mercedes",
                                                    LastName = "Orn"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Myrtle",
                                                    LastName = "Rath"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Shane",
                                                    LastName = "Dicki"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new()
                            {
                                FirstName = "Leonard",
                                LastName = "Bashirian",
                                TeamsUnderManagement = new()
                                {
                                    new()
                                    {
                                        Name = "Shell R&D Team 7",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Elias",
                                                    LastName = "Mills"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Jennifer",
                                                    LastName = "Hackett"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Herbert",
                                                    LastName = "Simonis"
                                                }
                                            }
                                        }
                                    },
                                    new()
                                    {
                                        Name = "Shell R&D Team 8",
                                        TeamMembers = new()
                                        {
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Jason",
                                                    LastName = "Okuneva"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Mike",
                                                    LastName = "Toy"
                                                }
                                            },
                                            new()
                                            {
                                                Member = new()
                                                {
                                                    FirstName = "Heather",
                                                    LastName = "Murphy"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    },
                }
            });

        db.SaveChanges();

        return db;
    }

    public static TestsDbContext GetMemoryContext()
    {
        var options = new DbContextOptionsBuilder<TestsDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .EnableSensitiveDataLogging()
            .Options;

        return new(options);
    }

    public static Company GetMicrosoftCompany()
    {
        return new()
        {
            Name = "Microsoft",
            FoundedLocation = "Albuquerque, New Mexico, U.S",
            Industry = "Technologies",
            Departments = new()
            {
                new()
                {
                    Name = "Microsoft Sales",
                    HeadOfDepartment = new()
                    {
                        FirstName = "Leslie",
                        LastName = "Kuhlman"
                    },
                    Managers = new()
                    {
                        new()
                        {
                            FirstName = "Carmen",
                            LastName = "Cartwright",
                            TeamsUnderManagement = new()
                            {
                                new()
                                {
                                    Name = "Microsoft Sales Team 1",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Santiago",
                                                LastName = "O'Keefe"
                                            },
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Ross",
                                                LastName = "Homenick"
                                            },
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Leona",
                                                LastName = "Wisoky"
                                            },
                                        }
                                    }
                                },
                                new()
                                {
                                    Name = "Microsoft Sales Team 2",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Floyd",
                                                LastName = "Glover"
                                            },
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Brandi",
                                                LastName = "Walter"
                                            },
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Daniel",
                                                LastName = "Kunde"
                                            },
                                        }
                                    }
                                }
                            }
                        },
                        new()
                        {
                            FirstName = "Gayle",
                            LastName = "Schiller",
                            TeamsUnderManagement = new()
                            {
                                new()
                                {
                                    Name = "Microsoft Sales Team 3",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Lynda",
                                                LastName = "Muller"
                                            },
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Lori",
                                                LastName = "Price"
                                            },
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Jeff",
                                                LastName = "Kulas"
                                            },
                                        }
                                    }
                                },
                                new()
                                {
                                    Name = "Microsoft Sales Team 4",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Floyd",
                                                LastName = "Dooley"
                                            },
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Sonia",
                                                LastName = "Renner"
                                            },
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Victoria",
                                                LastName = "VonRueden"
                                            },
                                        }
                                    }
                                }
                            }
                        },
                        new()
                        {
                            FirstName = "Veronica",
                            LastName = "Lindgren",
                            TeamsUnderManagement = new()
                            {
                                new()
                                {
                                    Name = "Microsoft Sales Team 5",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Terrance",
                                                LastName = "Reichert"
                                            },
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Pedro",
                                                LastName = "Morissette"
                                            },
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Lester",
                                                LastName = "Stiedemann"
                                            },
                                        }
                                    }
                                },
                                new()
                                {
                                    Name = "Microsoft Sales Team 6",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Tiffany",
                                                LastName = "Simonis"
                                            },
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Alison",
                                                LastName = "Schmitt"
                                            },
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Yolanda",
                                                LastName = "Stoltenberg"
                                            },
                                        }
                                    }
                                }
                            }
                        },
                    }
                },
                new()
                {
                    Name = "Microsoft IT",
                    HeadOfDepartment = new()
                    {
                        FirstName = "Barbara",
                        LastName = "Stehr"
                    },
                    Managers = new()
                    {
                        new()
                        {
                            FirstName = "Ignacio",
                            LastName = "Rice",
                            TeamsUnderManagement = new()
                            {
                                new()
                                {
                                    Name = "Microsoft IT Team 1>",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Eva",
                                                LastName = "Waelchi"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Brenda",
                                                LastName = "Hammes"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Desiree",
                                                LastName = "Purdy"
                                            }
                                        }
                                    }
                                },
                                new()
                                {
                                    Name = "Microsoft IT Team 2",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Eddie",
                                                LastName = "Rutherford"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Stuart",
                                                LastName = "Moen"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Sam",
                                                LastName = "Schroeder"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new()
                        {
                            FirstName = "Eileen",
                            LastName = "Bahringer",
                            TeamsUnderManagement = new()
                            {
                                new()
                                {
                                    Name = "Microsoft IT Team 3",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Sheri",
                                                LastName = "Mills"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Shawn",
                                                LastName = "Kub"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Jean",
                                                LastName = "Pfeffer"
                                            }
                                        }
                                    }
                                },
                                new()
                                {
                                    Name = "Microsoft IT Team 4",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Ollie",
                                                LastName = "Shanahan"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Alan",
                                                LastName = "Beatty"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Kay",
                                                LastName = "Schimmel"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new()
                        {
                            FirstName = "Frederick",
                            LastName = "Morissette",
                            TeamsUnderManagement = new()
                            {
                                new()
                                {
                                    Name = "Microsoft IT Team 5",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Aubrey",
                                                LastName = "Wehner"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Miguel",
                                                LastName = "Lehner"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Gwendolyn",
                                                LastName = "Gutkowski"
                                            }
                                        }
                                    }
                                },
                                new()
                                {
                                    Name = "Microsoft IT Team 6",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Milton",
                                                LastName = "Zulauf"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Hugh",
                                                LastName = "Windler"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Scott",
                                                LastName = "Kuphal"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new()
                        {
                            FirstName = "Elias",
                            LastName = "Schamberger",
                            TeamsUnderManagement = new()
                            {
                                new()
                                {
                                    Name = "Microsoft IT Team 7",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Irving",
                                                LastName = "Frami"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Wilbur",
                                                LastName = "Kilback"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Bessie",
                                                LastName = "Pfannerstill"
                                            }
                                        }
                                    }
                                },
                                new()
                                {
                                    Name = "Microsoft IT Team 8",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Marcos",
                                                LastName = "Tremblay"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "David",
                                                LastName = "Cassin"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Gene",
                                                LastName = "Pfannerstill"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                    }
                },
                new()
                {
                    Name = "Microsoft R&D",
                    HeadOfDepartment = new()
                    {
                        FirstName = "Winston",
                        LastName = "Bode"
                    },
                    Managers = new()
                    {
                        new()
                        {
                            FirstName = "Orlando",
                            LastName = "Smitham",
                            TeamsUnderManagement = new()
                            {
                                new()
                                {
                                    Name = "Microsoft R&D Team 1",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Forrest",
                                                LastName = "Skiles"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Billie",
                                                LastName = "Okuneva"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Annie",
                                                LastName = "Feil"
                                            }
                                        }
                                    }
                                },
                                new()
                                {
                                    Name = "Microsoft R&D Team 2",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Sonya",
                                                LastName = "Crona"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Warren",
                                                LastName = "Bernhard"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Catherine",
                                                LastName = "Keebler"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new()
                        {
                            FirstName = "Ruby",
                            LastName = "Beatty",
                            TeamsUnderManagement = new()
                            {
                                new()
                                {
                                    Name = "Microsoft R&D Team 3",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Whitney",
                                                LastName = "Hammes"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Emanuel",
                                                LastName = "Bechtelar"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Colin",
                                                LastName = "Jaskolski"
                                            }
                                        }
                                    }
                                },
                                new()
                                {
                                    Name = "Microsoft R&D Team 4",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Sharon",
                                                LastName = "Mraz"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Nettie",
                                                LastName = "Mayer"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Johanna",
                                                LastName = "Stanton"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new()
                        {
                            FirstName = "Lorena",
                            LastName = "Gottlieb",
                            TeamsUnderManagement = new()
                            {
                                new()
                                {
                                    Name = "Microsoft R&D Team 5",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Jana",
                                                LastName = "VonRueden"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Carrie",
                                                LastName = "Roberts"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Edgar",
                                                LastName = "Cole"
                                            }
                                        }
                                    }
                                },
                                new()
                                {
                                    Name = "Microsoft R&D Team 6",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Horace",
                                                LastName = "Ruecker"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Elbert",
                                                LastName = "Kling"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Justin",
                                                LastName = "Morar"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new()
                        {
                            FirstName = "Jeannie",
                            LastName = "Auer",
                            TeamsUnderManagement = new()
                            {
                                new()
                                {
                                    Name = "Microsoft R&D Team 7",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Doug",
                                                LastName = "Mosciski"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Emanuel",
                                                LastName = "Block"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Eric",
                                                LastName = "Reynolds"
                                            }
                                        }
                                    }
                                },
                                new()
                                {
                                    Name = "Microsoft R&D Team 8",
                                    TeamMembers = new()
                                    {
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Julius",
                                                LastName = "Stoltenberg"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Nathan",
                                                LastName = "Reynolds"
                                            }
                                        },
                                        new()
                                        {
                                            Member = new()
                                            {
                                                FirstName = "Barry",
                                                LastName = "Boyer"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                    }
                },
            }
        };
    }
}
