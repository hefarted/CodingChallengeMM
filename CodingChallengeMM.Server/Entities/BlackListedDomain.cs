﻿namespace CodingChallengeMM.Server.Entities
{
    public class BlacklistedDomain
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
