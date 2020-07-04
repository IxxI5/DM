namespace DM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDatabase : DbMigration
    {
        public override void Up()
        {
            // Registered admin@asp.net and guest@asp.net users 
            Sql(@"
                 INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'42c9f2f8-751f-40b4-be94-5e19b705d9f8', N'admin@asp.net', 0, N'ANohVmAva8l83TRXcpQ2Mm16lKJn1aXJlPGp3eB78zy1GPw25bXcmHF++U0kv1HrJQ==', N'b9b983e3-66b0-45f3-8660-b8cc04028e3e', NULL, 0, 0, NULL, 1, 0, N'admin@asp.net')
                 INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dc990fae-133d-4aa0-beed-4385671997e0', N'guest@asp.net', 0, N'AKLXMGwOAzb7VP3KG/3GW8rHRgigfA4Eqojijwmq6bvWG2T+Ss1o4U3OVWaT72Yu3Q==', N'ec5e6490-a1f6-40b9-84a6-b32d2bbf6dfa', NULL, 0, 0, NULL, 1, 0, N'guest@asp.net')
                ");

            // Role
            Sql(@"
                 INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'db7f2b72-2ffc-4e3b-ad01-e1f386d65ede', N'CanDeleteIncidents')
                ");

            // Role:CanDeleteIncidents (N'db7f2b72-2ffc-4e3b-ad01-e1f386d65ede') assign just to admin@asp.net (N'42c9f2f8-751f-40b4-be94-5e19b705d9f8'). Note: Here you can add more registered users with Role: CanDeleteIncidents
            Sql(@"
                 INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'42c9f2f8-751f-40b4-be94-5e19b705d9f8', N'db7f2b72-2ffc-4e3b-ad01-e1f386d65ede')
                ");

            // Incident entries
            Sql(@"
                 SET IDENTITY_INSERT [dbo].[Incidents] ON
                 INSERT INTO [dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES (1, N'PR-5000', N'Initial test failed', 1, 2)
                 INSERT INTO [dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES (3, N'PR-5002', N'GUI: New order of home screen indicators', 0, 1)
                 INSERT INTO [dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES (4, N'PR-5003', N'Logical Master shuts down if no valid configuration map found', 2, 2)
                 INSERT INTO [dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES (5, N'PR-5006', N'Checking return values in BB framework', 1, 0)
                 INSERT INTO [dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES (6, N'PR-5010', N'Seat GUI: Parallel lines between the curved Arrows', 0, 2)
                 INSERT INTO [dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES (8, N'PR-5015', N'D1-D4. The LEFT &amp; RIGHT commands are blocked', 1, 1)
                 INSERT INTO [dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES (9, N'PR-5016', N'Speed and SpeedPot indication are not present in case of no background', 2, 3)
                 INSERT INTO[dbo].[Incidents]  ([Id], [Name], [Title], [Severity], [Status]) VALUES(10, N'PR-5019', N'Seat GUI A FWD or REV in Seat triggers permanent GUI animation', 2, 0)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(11, N'PR-5023', N'DeviceIo does not set initial state of IOs', 0, 0)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(12, N'PR-5024', N'Long on command is not dedected', 2, 3)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(13, N'PR-5025', N'Implement IoService::getSwitchState(', 1, 2)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(14, N'PR-5026', N'Displaying issue under Configuration Map combined with Access Levels', 2, 2)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(15, N'PR-5028', N'BDI: Calculation of residual capacity is too deep in relation to real battery voltage', 0, 0)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(16, N'PR-5029', N'OS must cope with undocumented timer limitations of Keil''s CMSIS-RTOS', 2, 1)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(17, N'PR-5040', N'System shutdown at connect to iOS switch control', 0, 0)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(18, N'PR-5058', N'Parameter help text has a fixed text area length', 1, 1)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(19, N'PR-5059', N'A parameter group cannot be selected under a certain selection sequence', 2, 3)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(21, N'PR-5070', N'SpeedPot indication must not be visible', 2, 3)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(22, N'PR-5071', N'2-switch Seat doesn''t work correct', 1, 3)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(23, N'PR-5072', N'Double left in Click2Phone must be reserved for mode command', 0, 0)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(24, N'PR-5075', N'DSUB must be disabled for MS7', 1, 1)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(25, N'PR-5076', N'Off @ DSUB not regarded if on is possible', 2, 0)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(26, N'PR-5084', N'Sleep Power Mode functionality issues', 2, 2)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(27, N'PR-5086', N'System crash (shutdown) occasions', 2, 1)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(28, N'PR-5101', N'GUI: Battery charging is not directly updated in seat, aux or BT screen', 1, 2)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(29, N'PR-5102', N'Drive control turn ramp function radiants incorrect', 2, 1)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(30, N'PR-5104', N'User Drive Profiles are wrong', 2, 0)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(31, N'PR-5105', N'Default command direction not correct', 1, 1)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(32, N'PR-5107', N'Arrows are missing after function change', 0, 0)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(33, N'PR-5111', N'ON @ jack system crashes after startup', 1, 1)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(35, N'PR-5114', N'CAN prop Request Leads to Stop with out ramp Down', 2, 2)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(36, N'PR-5116', N'Aux list menu: left/right arrows are missing after up/dn command', 1, 2)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(37, N'PR-5120', N'BT: Pairing list will be lost if system is a longer time disconnected from power', 0, 3)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(38, N'PR-5131', N'Switch off does not work', 2, 3)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(39, N'PR-5133', N'Parameter Center Deadband is not regarded at all', 1, 1)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(40, N'PR-5242', N'Disconnection of Joystick and reconnection, triggers a GUI malfunction', 2, 1)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(41, N'PR-5246', N'DB Warnings', 0, 0)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(42, N'PR-5247', N'GUI out of memory', 1, 0)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(43, N'PR-5250', N'Overtake attempt leads to preoperational system', 0, 1)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(44, N'PR-5251', N'Incorrect data from TILT sensor', 1, 3)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(45, N'PR-5252', N'GobexServer State DataReady can Block GobexClient', 0, 2)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(46, N'PR-5254', N'Power up reason EE_POWER_UP_REASON_UNDEFINED not handled correctly', 1, 2)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(48, N'PR-5257', N'Temperature measurement with gyroscope sensor does not work', 0, 0)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(49, N'PR-5258', N'BB does not stop timer on requestConfigurable', 0, 1)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(50, N'PR-5260', N'Download SW when the device is in Test SW doesn''t work', 0, 2)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(51, N'PR-5261', N'Time when switching to test SW is too slow', 0, 3)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(52, N'PR-5266', N'Write Eep fails', 1, 0)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(53, N'PR-5271', N'BBState change requests supervision and errorhandling', 0, 3)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(54, N'PR-5272', N'CAN Heartbeat period too long', 0, 0)
                 INSERT INTO[dbo].[Incidents] ([Id], [Name], [Title], [Severity], [Status]) VALUES(55, N'PR-5277', N'Motor uncontrolled movement on Debuging', 0, 0)
                 SET IDENTITY_INSERT [dbo].[Incidents] OFF
                ");

        }
        
        public override void Down()
        {
        }
    }
}
